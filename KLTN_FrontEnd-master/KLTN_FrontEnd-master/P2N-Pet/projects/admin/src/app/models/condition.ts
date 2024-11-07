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
    this.Limit = 6;
    this.TotalPage = 0;
    this.TotalCount = 0;
    this.HasPrevious = false;
    this.HasNext = false;
  }
}

export class MemberCondtion {
  fullname: string;
  phone: string;
  email: string;
  status: number;
  order: number;
  fromdate: any;
  todate: any;
  frombirthyear: number;
  tobirthyear: number;
  schoolid: number;
  kindschoolid: number;

  constructor() {
    this.fullname = '';
    this.phone = '';
    this.email = '';
    this.status = 1;
    this.order = 10;
    this.fromdate = null;
    this.todate = null;
    this.frombirthyear = 0;
    this.tobirthyear = 0;
    this.schoolid = 0;
    this.kindschoolid = 0;
  }
}
