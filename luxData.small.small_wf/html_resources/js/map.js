const map = new ol.Map({
    target: 'map',
    layers: [
        new ol.layer.Tile({
            source: new ol.source.OSM()
        })
    ],
    view: new ol.View({
        center: ol.proj.fromLonLat([37.41, 8.82]),
        zoom: 4
    })
});

const layerManager = new LayerManager(map);
const featureTranslator = new FeatureTranslator(map);
const interactionManager = new InteractionManager(map, layerManager.source);
interactionManager.setInteraction(Geometry.HAND);