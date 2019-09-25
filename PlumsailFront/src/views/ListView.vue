<template>
    <div class="wrapper">
        <div class="search-wrapper">
            <input
                type="search"
                class="form-input" 
                v-model="searchString" 
            />
            <img class="icon" src="../../public/images/search.png" />
        </div>
        <table>
            <tbody>
                <tr 
                    v-for="object in filteredObject"
                    :key="object.id"
                >
                    <td 
                        v-for="index in columnCount"
                        :key="index"
                    >
                        <table-cell 
                            v-if="object.fields[index - 1]" 
                            :field="object.fields[index - 1]"
                        />
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
</template>

<script>
import TableCell from '../components/list/TableCell';

import { mapGetters } from 'vuex';

export default {
    components:{
        TableCell
    },
    data(){
        return {
            searchString: ''
        }
    },
    computed:{
        ...mapGetters({
            objects: 'objects/DATA'
        }),
        columnCount() {
            return Math.max(...this.objects.map(object => object.fields.length));
        },
        filteredObject(){
            return this.objects.filter(object => 
                object.fields.some(field => 
                    field.values.some(value =>
                        value.includes(this.searchString))));
        }
    }
}
</script>

<style scoped>
.wrapper {
    overflow-x: auto;
}

.form-input {
    width: 200px;
}

.icon{
    height: 30px;
    margin-left: 5px;
}

.search-wrapper{
    display: flex;
    justify-content: flex-end;
    margin-bottom: 15px;
}

.wrapper::-webkit-scrollbar {
    width: 6px;
}

.wrapper::-webkit-scrollbar-thumb {
    border-radius: 10px;
}

.wrapper::-webkit-scrollbar-track {
    border-radius: 10px;
}

table{
    border-collapse: collapse;
    width: 100%;
}

tr td{
  border-top: 1px solid rgb(210,210,215);
}

tr:last-child td{
  border-bottom: 1px solid rgb(210,210,215);
}

td {
    padding: 3px;
}
</style>