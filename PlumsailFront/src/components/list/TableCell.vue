<template>
    <div v-if="showList">
        <ul>
            <li 
                v-for="(value,index) in field.values"
                :key="index"
            >
                {{value}}
            </li>
        </ul>
    </div>
    <div v-else>{{field.values[0]}}</div>
</template>

<script>
export default {
    props: {
        field: Object
    },
    computed:{
        showList(){
            return this.field.values.length > 1;
        }
    }
}
</script>