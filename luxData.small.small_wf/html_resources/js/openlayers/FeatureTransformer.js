class FeatureTransformer {
    static getWkt(feature) {
        let format = new ol.format.WKT()

        let wkt = format.writeFeature(feature, {
            dataProjection: 'EPSG:4326',
            featureProjection: 'EPSG:3857'
        })

        return wkt;
    }
}