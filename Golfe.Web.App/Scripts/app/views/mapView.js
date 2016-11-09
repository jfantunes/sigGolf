define(['jquery', 'backbone', 'underscore','map/sourceController'],
    function ($, Backbone, _, Source) {

        var MapView = Backbone.View.extend({

            initialize: function () {
                var layerSwitcher = new ol.control.LayerSwitcher({});
                this.map = new ol.Map({
                    controls: ol.control.defaults().extend([
                    new ol.control.FullScreen()
                    ]),
                    target: 'map',
                    view: new ol.View({
                        center: ol.proj.transform([-8.65502715, 41.06275371], 'EPSG:4326', 'EPSG:3857'),
                        zoom: 15,
                        minZoom: 14,
                        maxZoom: 19
                    })
                });
                this.popup = new ol.Overlay.Popup();
                this.map.addOverlay(this.popup);
                this.map.addControl(layerSwitcher);
                this.addBaseLayers();
                this.addHolesLayers();
                this.addTrainingLayers();
                this.addSorrodingAreas();
                this.map.on('singleclick', _.bind(this.showPopUpBasedOnClick,this,event));
                
            },

            addBaseLayers: function () {
                var layers = new ol.layer.Group({
                    title: 'Base maps',
                    layers: [
                        new ol.layer.Tile({
                            title: 'Mapa',
                            type: 'base',
                            visible: true,
                            source: new ol.source.BingMaps({
                                imagerySet: 'Road',
                                key: 'AgXzR3TIdjxG_ajTiAuPZbQyXaleiS2PpSAaaGNAcXDmRe2pJDRGPYCCEq_TInal'
                            })
                        }),
                        new ol.layer.Tile({
                            title: 'Satelite',
                            type: 'base',
                            visible: false,
                            source: new ol.source.BingMaps({
                                imagerySet: 'Aerial',
                                key: 'AgXzR3TIdjxG_ajTiAuPZbQyXaleiS2PpSAaaGNAcXDmRe2pJDRGPYCCEq_TInal'
                            })
                        })
                    ],

                })

                this.map.addLayer(layers);


            },

            addHolesLayers: function () {
                var that = this;
                for (var nBuraco = 1; nBuraco <= 9; nBuraco++) {
                    that.map.addLayer(new ol.layer.Group({
                        title: 'Buraco ' + nBuraco,
                        layers: that.generateLayers([{ 'Tee': 'tee' }, { 'Green': 'green' },
                        { 'Avant-Green': 'avantgreen' }, { 'Fairway': 'fairway' },
                        { 'Semi-Rought': 'semirought' }, { 'Bunker': 'bunker' }, { 'Bandeira': 'buraco' }], nBuraco)
                    }));
                }
            },

            addTrainingLayers: function () {
                var that = this;
                this.map.addLayer(new ol.layer.Group({
                    title: 'Areas Treino',
                    layers: that.generateLayers([{ 'Chipping-Green': 'chipping_green' }, { 'Driving-Range': 'driving_range' }, { 'Putting-Green': 'putting_green' }], 0)
                }));
            },

            addSorrodingAreas: function () {
                var that = this;
                this.map.addLayer(new ol.layer.Group({
                    title: 'Areas Envolventes',
                    layers: that.generateLayers([{ 'Rought': 'rought' }, { 'Caminhos': 'caminhos' }], 0)
                }))
            },

            generateLayers: function (layers, nBuraco) {
                var generatedLayers = [];
                var that = this;
                layers.forEach(function (layer) {
                    var layerTitle = Object.keys(layer)[0];
                    var layerName = layer[layerTitle];
                    var currentSource = new Source(layerName, nBuraco);
                    currentSource.setFilter();
                    var layerVector = new ol.layer.Vector({
                        source: currentSource.getSource(),
                        title: layerTitle,
                        visible: false,
                        style: that.setStyleBasedOnLayer(layerName)
                    });

                    generatedLayers.push(layerVector);
                });
                return generatedLayers;
            },

            setStyleBasedOnLayer: function (layerName) {
                switch (layerName) {
                    case 'tee':
                        style = new ol.style.Style({
                            stroke: new ol.style.Stroke({
                                color: '#31A559',
                                width: 1
                            }),
                            fill: new ol.style.Fill({
                                color: '#31A559'
                            })
                        });
                        break;
                    case 'green':
                        style = new ol.style.Style({
                            stroke: new ol.style.Stroke({
                                color: '#3BD16F',
                                width: 1
                            }),
                            fill: new ol.style.Fill({
                                color: '#3BD16F'
                            })
                        });
                        break;
                    case 'avantgreen':
                        style = new ol.style.Style({
                            stroke: new ol.style.Stroke({
                                color: '#3EC26C',
                                width: 1
                            }),
                            fill: new ol.style.Fill({
                                color: '#3EC26C'
                            })
                        });
                        break;
                    case 'fairway':
                        style = new ol.style.Style({
                            stroke: new ol.style.Stroke({
                                color: '#7FD79E',
                                width: 1
                            }),
                            fill: new ol.style.Fill({
                                color: '#7FD79E'
                            })
                        });
                        break;
                    case 'semirought':
                        style = new ol.style.Style({
                            stroke: new ol.style.Stroke({
                                color: '#6FC98F',
                                width: 1
                            }),
                            fill: new ol.style.Fill({
                                color: '#6FC98F'
                            })
                        });
                        break;
                    case 'bunker':
                        style = new ol.style.Style({
                            stroke: new ol.style.Stroke({
                                color: '#EEEDC1',
                                width: 1
                            }),
                            fill: new ol.style.Fill({
                                color: '#EEEDC1'
                            })
                        });
                        break;
                        case 'caminhos':
                            style = new ol.style.Style({
                                stroke: new ol.style.Stroke({
                                    color: '#EEEDC1',
                                    width: 1
                                }),
                                fill: new ol.style.Fill({
                                    color: '#EEEDC1'
                                })
                            });
                            break;
                    case 'buraco':
                        style = new ol.style.Style({
                            image: new ol.style.Icon(/** @type {olx.style.IconOptions} */({
                                anchor: [0, 0],
                                anchorXUnits: 'fraction',
                                anchorYUnits: 'pixels',
                                scale: 0.6,
                                src: 'images/golf_flag.png'
                            }))
                        });
                        break;
                    case 'rought':
                        style = new ol.style.Style({
                            stroke: new ol.style.Stroke({
                                color: '#A4D5B4',
                                width: 1
                            }),
                            fill: new ol.style.Fill({
                                color: '#A4D5B4'
                            })
                        });
                        break;
                    case 'chipping_green':
                        style = new ol.style.Style({
                            stroke: new ol.style.Stroke({
                                color: '#5EB17A',
                                width: 1
                            }),
                            fill: new ol.style.Fill({
                                color: '#5EB17A'
                            })
                        });
                        break;
                    case 'driving_range':
                        style = new ol.style.Style({
                            stroke: new ol.style.Stroke({
                                color: '#5EB17A',
                                width: 1
                            }),
                            fill: new ol.style.Fill({
                                color: '#5EB17A'
                            })
                        });
                        break;
                    case 'putting_green':
                        style = new ol.style.Style({
                            stroke: new ol.style.Stroke({
                                color: '#5EB17A',
                                width: 1
                            }),
                            fill: new ol.style.Fill({
                                color: '#5EB17A'
                            })
                        });
                        break;
                }
                return style;
            },

            showPopUpBasedOnClick: function (context,evt) {

                var feature = this.map.forEachFeatureAtPixel(evt.pixel, function (feature, layer) {
                    return feature;
                });

                if (feature) {
                    var properties = feature.getProperties();
                    console.log(properties);
                    var html = '<div class="templatePopup"><dl>';
                    switch (properties.type) {
                        case "rought":
                            html += '<dt>ROUGHT</dt>' +
                            '<br>' +
                            '<dd><b>Area</b>:' + properties.area.toFixed(2) + ' m2</dd>' +
                            '<br>' +
                            '<dd><b>Tipo Vegetacao</b>:' + properties.tipo_relva + '</dd>' +
                            '<br>' +
                            '<dd><b>Altura Vegetacao</b>:' + properties.alt_relva.toFixed(2) + ' mm</dd>';
                            break;
                        case "semirought":
                            html += '<dt>SEMI-ROUGHT</dt>' +
                            '<br>' +
                            '<dd><b>Buraco</b>:' + properties.buraco + ' </dd>' +
                            '<br>' +
                            '<dd><b>Area</b>:' + properties.area.toFixed(2) + ' m2</dd>' +
                            '<br>' +
                            '<dd><b>Tipo Vegetacao</b>:' + properties.tipo_veget + '</dd>' +
                            '<br>' +
                            '<dd><b>Altura Vegetacao</b>:' + properties.alt_corte.toFixed(2) + ' mm</dd>';
                            break;
                        case "fairway":
                            html += '<dt>FAIRWAY</dt>' +
                            '<br>' +
                            '<dd><b>Buraco</b>:' + properties.buraco + ' </dd>' +
                            '<br>' +
                            '<dd><b>Area</b>:' + properties.area.toFixed(2) + ' m2</dd>' +
                            '<br>' +
                            '<dd><b>Tipo Relva</b>:' + properties.tipo_relva + '</dd>' +
                            '<br>' +
                            '<dd><b>Altura Relva</b>:' + properties.alt_relva.toFixed(2) + ' mm</dd>';
                            break;
                        case "avantgreen":
                            html += '<dt>AVANT-GREEN</dt>' +
                            '<br>' +
                            '<dd><b>Buraco</b>:' + properties.buraco + ' </dd>' +
                            '<br>' +
                            '<dd><b>Area</b>:' + properties.area.toFixed(2) + ' m2</dd>' +
                            '<br>' +
                            '<dd><b>Tipo Relva:</b>:' + properties.tipo_relva + '</dd>' +
                            '<br>' +
                            '<dd><b>Altura Relva</b>:' + properties.alt_relva.toFixed(2) + ' mm</dd>';
                            break;
                        case "green":
                            html += '<dt>GREEN</dt>' +
                            '<br>' +
                            '<dd><b>Buraco</b>:' + properties.buraco + ' </dd>' +
                            '<br>' +
                            '<dd><b>Area</b>:' + properties.area.toFixed(2) + ' m2</dd>' +
                            '<br>' +
                            '<dd><b>Tipo Relva</b>:' + properties.tipo_relva + '</dd>' +
                            '<br>' +
                            '<dd><b>Altura Relva</b>:' + properties.alt_relva.toFixed(2) + ' mm</dd>';
                            break;
                        case "tee":
                            html += '<dt>TEE</dt>' +
                            '<br>' +
                            '<dd><b>Buraco</b>:' + properties.buraco + ' </dd>' +
                            '<br>' +
                            '<dd><b>Area</b>:' + properties.area.toFixed(2) + ' m2</dd>' +
                            '<br>' +
                            '<dd><b>Tipo Relva:</b>:' + properties.tipo_relva + '</dd>' +
                            '<br>' +
                            '<dd><b>Altura Relva</b>:' + properties.altura_rel.toFixed(2) + ' mm</dd>';
                            break;
                        case "bunker":
                            html += '<dt>BUNKER</dt>' +
                            '<br>' +
                            '<dd><b>Buraco</b>:' + properties.buraco + ' </dd>' +
                            '<br>' +
                            '<dd><b>Area</b>:' + properties.area.toFixed(2) + ' m2</dd>';
                            break;
                        default:
                            html = '<div class="templatePopup"><h4>No feature available at this point</h4></div>';
                            break;

                    }
                    html += '</dl></div>';
                    this.popup.show(evt.coordinate, html);
                }
            }
        });

        return MapView;

    });