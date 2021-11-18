import { ETestActions, TestActions } from "../actions/test.actions";
import { initialTestState, TestState } from "../state/test.state";

export const testReducers = (
    state = initialTestState,
    action: TestActions
): TestState => {
    switch(action.type){
        case ETestActions.GetTestsSuccess: {
            return {
                ...state,
                tests:{
                    data : action.payload.data,
                    total : action.payload.total,
                    loading : action.payload.loading
                }
            };
        }
        case ETestActions.GetTestSuccess: {
            return {
                ...state,
                selectedTest: action.payload
            };
        }

        default:
            return state;
    }
}