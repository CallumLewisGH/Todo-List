<template>
    <template >
        <span>HELLO WORLD</span>
    </template>
</template>

<script setup>

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

class TodoList {
    constructor(list_name, todo_list,){
        this.list_name = list_name;
        this.todo_list = todo_list;
    }

    addTodoMainItem = () => {
        const item = new mainItem("MainItem INPUT", [])
        this.todo_list.push(item)
    }

    getListName = () => {
        return this.list_name;
    }

    getTodoList = () => {
        return this.todo_list;
    }

}

</script>