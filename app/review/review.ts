export interface IReview {
  Id: number;
  MovieId : number;
  UserName: string;
  Review: string;
}
export class Review implements IReview {
  Id: number;
  MovieId: number;
  UserName: string;
  Review: string;
}
