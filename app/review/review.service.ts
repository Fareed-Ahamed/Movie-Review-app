import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { IReview, Review } from './review';

@Injectable({
  providedIn: 'root'
})
export class ReviewService {
  private productUrl = 'https://localhost:44343';

  constructor(private http: HttpClient) { }

  getReviews(movieId : number): Observable<IReview[]> {
    return this.http.get<IReview[]>(`${this.productUrl}/Reviews/${movieId}`).pipe(
      tap(data => console.log('All: ' + JSON.stringify(data))),
      catchError(this.handleError)
    );
  }
  private handleError(err: HttpErrorResponse) {
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
  addReview(details: any): Observable<void> {
    return this.http.post<void>(`${this.productUrl}/AddReview`, details, {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    })
      .pipe(catchError(this.handleError));
  }
}
