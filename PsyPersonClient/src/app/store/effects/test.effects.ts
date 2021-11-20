import { Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { select, Store } from "@ngrx/store";
import { EMPTY, of } from "rxjs";
import { catchError, map, switchMap, withLatestFrom } from "rxjs/operators";
import { TestService } from "src/app/services/api/test.service";
import { ETestActions, GetTest, GetTests, GetTestsSuccess, GetTestSuccess } from "../actions/test.actions";
import { selectRoleList } from "../selectors/role.selector";
import { selectTestList } from "../selectors/test.selector";
import { AppState } from "../state/app.state";

@Injectable()
export class TestEffects{
    constructor(
        private service: TestService, 
        private store: Store<AppState>, 
        private actions$: Actions){}

    getTest$ = createEffect(() => 
    this.actions$.pipe(
        ofType<GetTest>(ETestActions.GetTest),
        map(action => action.payload),
        withLatestFrom(this.store.pipe(select(selectTestList))),
        switchMap(([id, tests]) => {
        const selectedTest = tests.data.filter(role => role.id === id)[0];
        return of(new GetTestSuccess(selectedTest));
        })  
    ));

    getTests$ = createEffect(() => 
    this.actions$.pipe(
        ofType<GetTests>(ETestActions.GetTests),
        switchMap((u) => this.service.getAll(u.payload).pipe(
            map(r => {r.loading = false; return r} ),
            map((tests) => new GetTestsSuccess(tests)),
            catchError((error) => {console.log('GetTests | error ',error); throw error})
        ))
    ));
}