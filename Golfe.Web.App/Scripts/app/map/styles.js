define(
    function() {
        var style;
        switch (name) {
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
            case 'bandeira':
                style = new ol.style.Style({
                    image: new ol.style.Icon(/** @type {olx.style.IconOptions} */({
                        anchor: [0, 0],
                        anchorXUnits: 'fraction',
                        anchorYUnits: 'pixels',
                        scale: 0.6,
                        src: 'data/golf_flag.png'
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
            case 'puttingreen':
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
            case 'drivingrange':
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
    });