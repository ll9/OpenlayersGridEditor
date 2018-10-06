class LayerManager {
	constructor(map) {
        this.source = new ol.source.Vector();
        this.layer = new ol.layer.Vector({source: this.source, projection : 'EPSG:4326'})
        this.format = new ol.format.GeoJSON({featureProjection: 'EPSG:3857'});

        map.addLayer(this.layer)
    }
    
    /**
     * Adds single feature to the map
     * @param {gejson string} geoJsonFeature 
     */
    addFeature(geoJsonFeature) {
        let feature = this.format.readFeature(geoJsonFeature);
        this.source.addFeature(feature);
    }

    /**
     * adds featureCollection to the map
     * @param {geosjon Featurecollection} geoJsonFeatureCollection 
     */
    addFeatures(geoJsonFeatureCollection) {
        let featureCollection = this.format.readFeatures(geoJsonFeatureCollection);
        this.source.addFeatures(featureCollection);
    }
}