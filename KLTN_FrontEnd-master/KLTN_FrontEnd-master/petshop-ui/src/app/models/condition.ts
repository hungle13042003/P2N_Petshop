import { FormatDaySearch } from "../heplers/utils";

export class Pagination {
  CurrentPage: number;
  CurrentDate: string;
  Limit: number;
  TotalPage: number;
  TotalCount: number;
  HasPrevious: boolean;
  HasNext: boolean;

  constructor() {
    this.CurrentPage = 0;
    this.CurrentDate = FormatDaySearch(new Date());
    this.Limit = 9;
    this.TotalPage = 0;
    this.TotalCount = 0;
    this.HasPrevious = false;
    this.HasNext = false;
  }
}