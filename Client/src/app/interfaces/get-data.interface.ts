import { Observable } from "rxjs";
import { KsiazkaClass } from "../classes/ksiazka.class";

export interface GetDataInterface {
    Get(): Observable<KsiazkaClass[]>;
    GetByID(id: number): Observable<KsiazkaClass>;
}