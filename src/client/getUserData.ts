import { getUserById, UserDTO } from "@/client";

export async function readUserDataById(inputId: number) {
    const response = await getUserById({path: {id: inputId}});
    if (response.data === undefined){
        return;
    }

    return response
};