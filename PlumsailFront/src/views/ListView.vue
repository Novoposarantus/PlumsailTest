<template>
    <div class="wrapper">
        <table>
            <tbody>
                <tr 
                    v-for="object in objects"
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
    computed:{
        ...mapGetters({
            objects: 'objects/DATA'
        }),
        columnCount() {
            return Math.max(...this.objects.map(object => object.fields.length));
        }
    }
}
</script>

<style scoped>
.wrapper {
    overflow-x: auto;
}

.wrapper::-webkit-scrollbar {
    width: 6px;
    background-color: #f0f8ff;
}

.wrapper::-webkit-scrollbar-thumb {
    background-color: #363636cc;
    border-radius: 10px;
}

.wrapper::-webkit-scrollbar-track {
    box-shadow: inset 0 0 6px #9facb9;
    background-color: #ffffff00;
    border-radius: 10px;
}

table{
    border-collapse: collapse;
    width: 100%;
}

tr:not(:first-child) td{
  border-top: 1px solid rgb(210,210,215);
}

td {
padding: 3px;
}
</style>