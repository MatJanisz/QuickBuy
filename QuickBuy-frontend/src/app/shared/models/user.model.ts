export class UserModel {
  constructor(
    public email: string,
    public amountOfMoney: string,
    public isAdmin: boolean,
    public isBlocked: boolean,
    public id: string,
    public numberOfBoughtItems
  ) {}
}
