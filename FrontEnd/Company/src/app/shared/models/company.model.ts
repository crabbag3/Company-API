export class CompanyModel {
  public name: string;
  public exchange: string;
  public ticker: string;
  public isin: string;
  public website: string;

  constructor(
    name?: string,
    exchange?: string,
    ticker?: string,
    isin?: string,
    website?: string
  ) {
    this.name = name || '';
    this.exchange = exchange || '';
    this.ticker = ticker || '';
    this.isin = isin || '';
    this.website = website || '';
  }
}
