import { Component, OnInit } from '@angular/core';
import { IMovie, Movie } from './product';
import { ProductService } from './product.service';
import { Router } from '@angular/router';

@Component({
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})


export class ProductComponent {
  pagetitle: string = 'Product List';
  imageWidth: number = 70;
  imageMargin: number = 4;
  showImg: boolean = false;
  _listFilter: string;
  errorMessage: any;
  popupType = ''
  public products: IMovie[] = [];
  public ProductDetails: Movie = new Movie();
  public display: any;
  role: string = window.sessionStorage.getItem("Role");
  //get listFilter(): string {
  //  return this._listFilter;
  //}
  //set listFilter(value: string) {
  //  this._listFilter = value;
  //  this.filteredProducts = this.listFilter ? this.performFilter(this.listFilter) : this.products;
  //}
  filteredProducts: IMovie[];
  
  toogleImage(): void {
    this.showImg = !this.showImg;
  }
  ngOnInit(): void {
    console.log(this.role);
    this.productService.getProducts().subscribe({
      next: products => {
        this.products = products
        this.filteredProducts = this.products;
      },
      error: err => this.errorMessage
    });
  }

  constructor(private productService: ProductService, private router: Router) {
    this.filteredProducts = this.products;
  }

  deleteId(id)
  {
    this.productService.deleteId(id).subscribe(res => {
      this.products.splice(this.products.map(m => { return m }).indexOf(id), 1)
    }, err => { this.errorMessage });
  }
    refresh()
    {
      this.productService.getProducts().subscribe(msg => {
        this.products = msg
        this.filteredProducts = this.products;
      }, err => { this.errorMessage });
    }
  updateDetails() {
    var request = {
      id: this.ProductDetails.Id,
      moviename: this.ProductDetails.MovieName,
      synopsis: this.ProductDetails.Synopsis,
      genre: this.ProductDetails.Genre
    };
    this.productService.updateDetails(request).subscribe(result => { this.refresh() });
  }
  addMovie() {
    var request = {
      moviename: this.ProductDetails.MovieName,
      synopsis: this.ProductDetails.Synopsis,
      genre: this.ProductDetails.Genre
    };
    this.productService.addDetails(request).subscribe(result => { this.refresh() });
  }

  openAddModel() {
    this.popupType = 'add';
    this.display = 'block';
    this.ProductDetails.MovieName = '';
    this.ProductDetails.Synopsis = '';
    this.ProductDetails.Genre = '';
  }

  openModel(ProductDetail: Movie) {
    this.popupType = 'update';
    this.display = 'block';
    this.ProductDetails.MovieName = ProductDetail.MovieName ;
    this.ProductDetails.Id = ProductDetail.Id ;
    this.ProductDetails.Synopsis = ProductDetail.Synopsis;
    this.ProductDetails.Genre = ProductDetail.Genre;
  }

  openReviews(movieDetail: Movie) {
    this.router.navigate(['/reviews'], { queryParams: { movieName: movieDetail.MovieName, movieId: movieDetail.Id, synopsis: movieDetail.Synopsis } });
  }

  closeModel() {
    this.display = 'none';
    this.refresh();
  }

  add()
  {
    this.addMovie();
    this.closeModel();
  }

  logout() {
    this.router.navigate(['/', 'welcome']);
  }

  submit()
  {
    this.updateDetails();
    this.closeModel();
  }
}
