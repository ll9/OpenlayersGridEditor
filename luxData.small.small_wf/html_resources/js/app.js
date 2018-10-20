const vue = new Vue({
    el: '#app',
    data: {
        selectedInteraction: Geometry.HAND,
    },
    computed: {

    },
    watch: {
        selectedInteraction: function (newVal, oldVal) {
            interactionManager.setInteraction(newVal)
        }
    }
})