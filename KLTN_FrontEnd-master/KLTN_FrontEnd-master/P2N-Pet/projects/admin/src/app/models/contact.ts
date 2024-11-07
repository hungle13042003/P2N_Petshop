export class Contact{
    public Id: number;
    public Name: string;
    public Email: string;
    public Phone: string;
    public Subject: string;
    public Content: string;
    public StatusText: string;
}

export class ContactCondition {
    Name: string;
    Email: string;
    Phone: string;
    Subject: string;
    Status: string;
  
    constructor() {
      this.Name = '';
      this.Email = '';
      this.Phone = '';
      this.Subject = '';
      this.Status = '0';
    }
  }