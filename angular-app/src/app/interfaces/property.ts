export interface Property {
    id: string;
    name: string;
    ownershipChanges: OwnershipChange[];
}

export interface OwnershipChange {
    effectiveDate: Date;
    contact: Contact;
    askingPrice: Money;
    soldPrice: Money;
    soldPriceAtUsd: Money;
}

export interface Contact {
    firstName: string;
    lastName: string;
}

export interface Money {
    amount: number;
    currency: string;
}