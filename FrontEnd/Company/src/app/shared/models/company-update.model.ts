import { CompanyModel } from './company.model';

export class CompanyUpdateModel extends CompanyModel {
  public id: string;

  constructor(
    id?: string,
    name?: string,
    exchange?: string,
    ticker?: string,
    isin?: string,
    website?: string,

  ) {
    super(name, exchange, ticker, isin, website);

    this.id = id || '';
  }
}
