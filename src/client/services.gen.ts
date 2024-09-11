// This file is auto-generated by @hey-api/openapi-ts

import { createClient, createConfig, type Options } from '@hey-api/client-fetch';
import type { GetUserByIdData, GetUserByIdError, GetUserByIdResponse, PutUserByIdData, PutUserByIdError, PutUserByIdResponse, DeleteUserByIdData, DeleteUserByIdError, DeleteUserByIdResponse, GetByIdData, GetByIdError, GetByIdResponse, PostUserData, PostUserError, PostUserResponse, PutUserTodoListByIdData, PutUserTodoListByIdError, PutUserTodoListByIdResponse, DeleteUserTodoListByIdData, DeleteUserTodoListByIdError, DeleteUserTodoListByIdResponse, PostUserTodoListData, PostUserTodoListError, PostUserTodoListResponse, PutUserTodoListTaskByIdData, PutUserTodoListTaskByIdError, PutUserTodoListTaskByIdResponse, DeleteUserTodoListTaskByIdData, DeleteUserTodoListTaskByIdError, DeleteUserTodoListTaskByIdResponse, PostUserTodoListTaskData, PostUserTodoListTaskError, PostUserTodoListTaskResponse, PutUserTodoListTaskSubtaskByIdData, PutUserTodoListTaskSubtaskByIdError, PutUserTodoListTaskSubtaskByIdResponse, DeleteUserTodoListTaskSubtaskByIdData, DeleteUserTodoListTaskSubtaskByIdError, DeleteUserTodoListTaskSubtaskByIdResponse, PostUserTodoListTaskSubtaskData, PostUserTodoListTaskSubtaskError, PostUserTodoListTaskSubtaskResponse } from './types.gen';

export const client = createClient(createConfig());

export const getUserById = <ThrowOnError extends boolean = false>(options: Options<GetUserByIdData, ThrowOnError>) => { return (options?.client ?? client).get<GetUserByIdResponse, GetUserByIdError, ThrowOnError>({
    ...options,
    url: '/user/{id}'
}); };

export const putUserById = <ThrowOnError extends boolean = false>(options: Options<PutUserByIdData, ThrowOnError>) => { return (options?.client ?? client).put<PutUserByIdResponse, PutUserByIdError, ThrowOnError>({
    ...options,
    url: '/user/{id}'
}); };

export const deleteUserById = <ThrowOnError extends boolean = false>(options: Options<DeleteUserByIdData, ThrowOnError>) => { return (options?.client ?? client).delete<DeleteUserByIdResponse, DeleteUserByIdError, ThrowOnError>({
    ...options,
    url: '/user/{id}'
}); };

export const getById = <ThrowOnError extends boolean = false>(options: Options<GetByIdData, ThrowOnError>) => { return (options?.client ?? client).get<GetByIdResponse, GetByIdError, ThrowOnError>({
    ...options,
    url: '/{id}'
}); };

export const postUser = <ThrowOnError extends boolean = false>(options: Options<PostUserData, ThrowOnError>) => { return (options?.client ?? client).post<PostUserResponse, PostUserError, ThrowOnError>({
    ...options,
    url: '/user'
}); };

export const putUserTodoListById = <ThrowOnError extends boolean = false>(options: Options<PutUserTodoListByIdData, ThrowOnError>) => { return (options?.client ?? client).put<PutUserTodoListByIdResponse, PutUserTodoListByIdError, ThrowOnError>({
    ...options,
    url: '/user/todoList/{id}'
}); };

export const deleteUserTodoListById = <ThrowOnError extends boolean = false>(options: Options<DeleteUserTodoListByIdData, ThrowOnError>) => { return (options?.client ?? client).delete<DeleteUserTodoListByIdResponse, DeleteUserTodoListByIdError, ThrowOnError>({
    ...options,
    url: '/user/todoList/{id}'
}); };

export const postUserTodoList = <ThrowOnError extends boolean = false>(options: Options<PostUserTodoListData, ThrowOnError>) => { return (options?.client ?? client).post<PostUserTodoListResponse, PostUserTodoListError, ThrowOnError>({
    ...options,
    url: '/user/todoList'
}); };

export const putUserTodoListTaskById = <ThrowOnError extends boolean = false>(options: Options<PutUserTodoListTaskByIdData, ThrowOnError>) => { return (options?.client ?? client).put<PutUserTodoListTaskByIdResponse, PutUserTodoListTaskByIdError, ThrowOnError>({
    ...options,
    url: '/user/todoList/task/{id}'
}); };

export const deleteUserTodoListTaskById = <ThrowOnError extends boolean = false>(options: Options<DeleteUserTodoListTaskByIdData, ThrowOnError>) => { return (options?.client ?? client).delete<DeleteUserTodoListTaskByIdResponse, DeleteUserTodoListTaskByIdError, ThrowOnError>({
    ...options,
    url: '/user/todoList/task/{id}'
}); };

export const postUserTodoListTask = <ThrowOnError extends boolean = false>(options: Options<PostUserTodoListTaskData, ThrowOnError>) => { return (options?.client ?? client).post<PostUserTodoListTaskResponse, PostUserTodoListTaskError, ThrowOnError>({
    ...options,
    url: '/user/todoList/task'
}); };

export const putUserTodoListTaskSubtaskById = <ThrowOnError extends boolean = false>(options: Options<PutUserTodoListTaskSubtaskByIdData, ThrowOnError>) => { return (options?.client ?? client).put<PutUserTodoListTaskSubtaskByIdResponse, PutUserTodoListTaskSubtaskByIdError, ThrowOnError>({
    ...options,
    url: '/user/todoList/task/subtask/{id}'
}); };

export const deleteUserTodoListTaskSubtaskById = <ThrowOnError extends boolean = false>(options: Options<DeleteUserTodoListTaskSubtaskByIdData, ThrowOnError>) => { return (options?.client ?? client).delete<DeleteUserTodoListTaskSubtaskByIdResponse, DeleteUserTodoListTaskSubtaskByIdError, ThrowOnError>({
    ...options,
    url: '/user/todoList/task/subtask/{id}'
}); };

export const postUserTodoListTaskSubtask = <ThrowOnError extends boolean = false>(options: Options<PostUserTodoListTaskSubtaskData, ThrowOnError>) => { return (options?.client ?? client).post<PostUserTodoListTaskSubtaskResponse, PostUserTodoListTaskSubtaskError, ThrowOnError>({
    ...options,
    url: '/user/todoList/task/subtask'
}); };