export interface IMovie {
  Id: number;
  MovieName: string;
  Synopsis: string;
  Genre: string;
  //imageUrl: string;
}
export class Movie implements IMovie {
  Id: number;
  MovieName: string;
  Synopsis: string;
  Genre: string;
  //imageUrl: string;
}
