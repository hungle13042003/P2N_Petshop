export class OrderCreateCondition{
    Name: string;
    Email: string;
    Phone: string;
    Address: string;
    Note: string;

    constructor(){
        this.Name = "";
        this.Email = "";
        this.Phone = "";
        this.Address = "";
        this.Note = "";
    }
}

export class OrderHistoryList{
    OrderId: number;
    CreateOrder: string;
    TotalMoney: number;
    NumOrder: number;
    Address: string;
    StatusOrderId: number;
    StatusOrderText: string;
}