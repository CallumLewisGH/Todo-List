<template>
    <div class="todo_list_header">
    <span>{{props.todo_list.value.list_name}}</span>
    </div>
        <template v-for="items in props.todo_list.value.todo_list">
            <div class="todo_list">
                <li>{{items}}</li>
            </div>
        </template>

</template>

<script setup>
import { ref, onMounted, defineProps, defineEmits } from 'vue';

const props = defineProps({
    todo_list: {
        type: Object,
        required: true,
    }
})

class mainItem {
    constructor(item_input, sub_item_list,){
        this.item_input = item_input;
        this.sub_item_list = sub_item_list;
    }

    addTodoSubItem = () => {
        this.sub_item_list.push("SubItem INPUT")
    }

    getItemInput = () => {
        return this.item_input;
    }

    getSubItemList = () => {
        return this.sub_item_list;
    }

}


const emit = defineEmits(['updateList'])

</script>