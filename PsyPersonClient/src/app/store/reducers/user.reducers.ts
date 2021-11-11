import { createReducer, on } from "@ngrx/store";
import { UserDto } from "src/app/models/users.models";
import { EUserActions, GetUsersSuccess,UserActions } from "../actions/user.actions";
import { initialUserState, UserState } from "../state/user.state";

export const userReducers = (
    state = initialUserState,
    action: UserActions
): UserState => {
    switch(action.type){
        case EUserActions.GetUsersSuccess: {
            return {
                ...state,
                users: action.payload
            };
        }
        case EUserActions.GetUserSuccess: {
            return {
                ...state,
                selectedUser: action.payload
            };
        }

        default:
            return state;
    }
}