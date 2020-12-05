import { Injectable } from '@angular/core';
import { IMovie, Movie } from './product';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  private productUrl = 'https://localhost:44343';

  constructor(private http: HttpClient) { }

  getProducts(): Observable<IMovie[]> {
    return this.http.get<IMovie[]>(`${this.productUrl}/movies`).pipe(
      tap(data => console.log('All: ' + JSON.stringify(data))),
      catchError(this.handleError)
    );
  }
  private handleError(err: HttpErrorResponse)
  {
    let errorMessage = '';
    if (err.error instanceof ErrorEvent) {
      errorMessage = `An error occured: ${err.error.message}`;
    }
    else {
      errorMessage = `Server returned code: ${err.status}, error message is: ${err.message}`;
    }
    console.error(errorMessage);
    return throwError(errorMessage);
  }

  deleteId(id: number): Observable<void>
  {
    return this.http.post<void>(`${this.productUrl}/DeleteMovie/${id}`, {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    })
      .pipe(catchError(this.handleError));
  }

  updateDetails(details: any): Observable<void>
  {
    return this.http.put<void>(`${this.productUrl}/UpdateMovie`, details, {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    })
      .pipe(catchError(this.handleError));
  }

  addDetails(details: any): Observable<void> {
    return this.http.post<void>(`${this.productUrl}/CreateMovie`, details, {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    })
      .pipe(catchError(this.handleError));
  }

  submit(details: Movie): Observable<Movie>
  {
    return this.http.post<Movie>(this.productUrl, details, {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    })
      .pipe(catchError(this.handleError));
  }
}
