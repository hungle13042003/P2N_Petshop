export class CommentModel {
    ProductDetailId: number;
    Content: string;
    CommentRootId?: number;

    constructor(){
        this.ProductDetailId = 0;
        this.Content = "";
        this.CommentRootId = 0;
    }
}

export class CommentCondition{
    ProductCommentId : number;
    Content: string;
    Rating: number;
    CommentRootId?: number;
    constructor(){
        this.ProductCommentId = 0;
        this.Content = '';
        this.Rating = 0;
        this.CommentRootId = 0;
        
    }
}