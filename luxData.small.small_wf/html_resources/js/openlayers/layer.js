class LayerManager {
	constructor(map) {
		this.map = map;
		this.source = new ol.source.Vector();
		this.layer = new ol.layer.Vector({
			source: this.source,
			style: function (feature) {
				return new ol.style.Style({
					image: new ol.style.Circle({
						fill: new ol.style.Fill({
							color: "dodgerblue"
						}),
						stroke: new ol.style.Stroke({
							color: "white",
							width: 2
						}),
						radius: 8
					}),
					fill: new ol.style.Fill({
						color: "rgba(0, 0, 255, 0.05)"
					}),
					stroke: new ol.style.Stroke({
						color: "blue",
						width: 2
					}),
				})
			}
		})
		this.format = new ol.format.GeoJSON({
			featureProjection: 'EPSG:3857'
		});

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

	/**
	 * Zooms to the extent of the vector layer
	 */
	fitZoom() {
		this.map.getView().fit(this.source.getExtent(), {
			duration: 1000
		})
	}
}