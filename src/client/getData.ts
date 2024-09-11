import { getById, TodoListObjectDTO } from "@/client";

export async function readDataById(inputId: number) {
    const response = await getById({path: {id: inputId}});
    if (response.data === undefined){
        return;
    }

    const ListRes = response.data.map(todoList => {
        const res: TodoListObjectDTO = {
            listName: todoList.listName,
            listId: todoList.listId,
            todoListObject: todoList.todoListObject
        } 
        return res;
    })

    return ListRes

}