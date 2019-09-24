<template>
    <img class="icon" v-if="showIcons" :src="icon"/>
    <span v-else>{{text}}</span>
</template>

<script>
export default {
    props: {
        text: String,
        icon: String
    },
    data(){
        return{
            windowWidth: window.innerWidth
        }
    },
    computed:{
        showIcons(){
            return this.windowWidth < 400;
        }
    },
    methods:{
        handleResize() {
            this.windowWidth = window.innerWidth;
        }
    },
    created(){
        window.addEventListener("resize", this.handleResize);
    },
    destroyed(){
        window.removeEventListener("resize", this.handleResize);
    }
}
</script>

<style scoped>
.icon {
    height: 20px;
}
</style>