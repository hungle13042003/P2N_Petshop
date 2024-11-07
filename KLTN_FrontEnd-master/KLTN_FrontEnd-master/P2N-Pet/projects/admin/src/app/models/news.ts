export class NewsCondition{
  Title : string;
  TypeNewsId: number
  Status : number

  constructor(){
    this.Title = ''
    this.TypeNewsId = 0
    this.Status = 0
  }
}

export class TypeNewsSelection{
  Id: number
  Title: string
}
