<template>

</template>

<script setup>
class TodoList {
    constructor(list_name, todo_list,){
        this.list_name = list_name;
        this.todo_list = todo_list;
    }

    getListName = () => {
        return this.list_name;
    }

    getTodoList = () => {
        return this.todo_list;
    }

}

let TodoList1 = new TodoList(List1, ["do X", "Do Y", "Do Z"])
console.log(todoList1.getListName)
</script>