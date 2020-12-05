import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ReviewService } from './review.service';
import { IReview, Review } from './review';

@Component({
  selector: 'app-review',
  templateUrl: './review.component.html',
  styleUrls: ['./review.component.css']
})
export class ReviewComponent implements OnInit {
  movieName: string;
  movieId: number;
  synopsis: string;
  errorMessage: any;
  public reviews: IReview[] = [];
  public ReviewDetails: Review = new Review();
  display: any;
  selectedReview: any;
  popupType: any;
  userName: string = window.sessionStorage.getItem("userName");
  constructor(private router: Router, private route: ActivatedRoute, private reviewService: ReviewService) { }

  ngOnInit() {
    this.route.queryParams.subscribe(params => {
      this.movieName = params['movieName'];
      console.log("Movie Name " + this.movieName);
      this.movieId = params['movieId'];
      console.log("Movie Id" + this.movieId);
      this.synopsis = params['synopsis'];
      console.log("Synopsis" + this.synopsis);
    });

    this.ReviewDetails.MovieId = this.movieId;
    this.ReviewDetails.UserName = this.userName;

    this.reviewService.getReviews(this.movieId).subscribe(msg => {
      this.reviews = msg
    }, err => { this.errorMessage });

    console.log(this.reviews);
  }

  viewReview(review: Review) {
    this.display = 'block';
    this.selectedReview = review
    this.popupType = 'viewReview'
    console.log('this.selectedReview', this.selectedReview)
  }

  addReview() {
    this.display = 'block';
    this.popupType = 'addReview'
  }

  goBack() {
    this.router.navigate(['/', 'products']);
  }

  closeModel() {
    this.display = 'none';
  }

  refresh() {
    this.reviewService.getReviews(this.movieId).subscribe(msg => {
      this.reviews = msg
    }, err => { this.errorMessage });
  }

  saveReview() {
    this.reviewService.addReview(this.ReviewDetails).subscribe(res => { this.closeModel(), this.refresh() })
    console.log('this.ReviewDetails :', this.ReviewDetails);
  }

}
