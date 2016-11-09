define(['jquery'],
    function($) {
        var Source = function (layerName, nBuraco) {
            var that = this;
            this.layerName = layerName;
            this.numeroBuraco = nBuraco;
            this.dataParameters = {
                service: 'WFS',
                request: 'GetFeature',
                data: 'json',
                version: '1.1.0',
                typename: this.layerName,
                srsname: 'EPSG:3857',
                outputFormat: 'JSON'
            };
            this.source = new ol.source.Vector({
                loader: function (extent) {
                    $.ajax('http://localhost:8080/geoserver/golf/ows', {
                        type: 'GET',
                        data: that.dataParameters,
                    }).done(loadFeatures);
                },
                projection: 'EPSG:3857',
                strategy: ol.loadingstrategy.bbox
            });

            function loadFeatures(response) {
                var geoJson = new ol.format.GeoJSON();
                that.source.addFeatures(geoJson.readFeatures(response));

            };
        }
        Source.prototype.getSource = function () {
            return this.source;
        }

        Source.prototype.setFilter = function () {
            if (this.layerName != 'rought' && this.layerName != 'putting_green' && this.layerName != 'caminhos'&& this.layerName != 'driving_range' && this.layerName != 'chipping_green')
                this.dataParameters.CQL_FILTER = 'buraco=' + this.numeroBuraco;
        }
        return Source;
    });