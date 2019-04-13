Feature: Scenarios for Webpay API automation

@basic
 Scenario Outline: Access token for business API
Given I have an <endpoint>
When I call the post method for <clientid>, <clientsecret> and <granttype>
Then I am able to generate the access token <clientid>, <clientsecret> and <granttype>
Examples:
| endpoint               | clientid                             | clientsecret                                                     | granttype          |
| identity/connect/token | 84CD6CAA-3773-4101-B6EA-68FD6783D5BD | 2BB80D537B1DA3E38BD30361AA855686BDE0EACD7162FEF6A25FE97BF527A25B | client_credentials |

@basic
 Scenario Outline: Access token for webpay
Given I have an <endpoint>
When I call the post method for <clientid>, <clientsecret> and <granttype>
Then I am able to generate the access token with parameters <clientid>, <clientsecret>, <granttype>
Examples:
| endpoint               | clientid                             | clientsecret                         | granttype          |
| identity/connect/token | F80598DB-833B-4BB8-B8FA-DF10DBD959F7 | 50F9CDF5-2E36-4B62-8111-17A743CC06B5 | client_credentials |

@basic
Scenario Outline: Make a webpay payment using Various cards
Given I have some <endpoint> for webpay
When I am authorised to call the post method <cardHolderName>, <cardNumber>, <cvc>, <cardType>, <expiryDate>, <amount>, <businessId>, <bpayReferenceNumber>
Then I am able to generate a successful response <cardHolderName>, <cardNumber>, <cvc>, <cardType>, <expiryDate>, <amount>, <businessId>, <bpayReferenceNumber>
Examples:
| cardHolderName | cardNumber       | cvc  | cardType        | expiryDate | amount | businessId | bpayReferenceNumber | endpoint                    |
| John Doe       | 4111111111111111 | 123  | Visa            | 01/25      | 10     | QP1D1      | 18890571956         | Payments/v1.0/casual/webpay |
| John Doe       | 5431111111111111 | 124  | MasterCard      | 01/25      | 14     | QP1D1      | 18890571956         | Payments/v1.0/casual/webpay |
| John Doe       | 371111111111114  | 1234 | AmericanExpress | 01/25      | 10     | QP1D1      | 18890571956         | Payments/v1.0/casual/webpay |

@basic
 Scenario Outline: CRN Validation
Given I have some <endpoint> for business API
When I call the get method for business API
Then I am able to generate response with facility name and contract prefix 
Examples: 
| endpoint                                                       |
| business/v1/businessaccounts?BillerCode=374397&Crn=18890571956 |

@basic
Scenario Outline: Make a casual payment using Various cards
Given I have some <endpoint> for casual pay
When I call the method for casual payment with parameters <cardHolderName>, <cardNumber>, <cvc>, <cardType>, <expiryDate>, <amount>, <businessId>, <bpayReferenceNumber>
Then I am able to generate the response for parameters <cardHolderName>, <cardNumber>, <cvc>, <cardType>, <expiryDate>, <amount>, <businessId>, <bpayReferenceNumber>
Examples: 
| cardHolderName | cardNumber       | cvc   | cardType        | expiryDate | amount | businessId | bpayReferenceNumber | endpoint                        |
| John Doe       | 4111111111111111 | 123   | Visa            | 01/25      | 10     | DEA2      | 18890571956         | Payments/v1.0/casual/creditcard  |
| John Doe       | 5431111111111111 | 123   | MasterCard      | 01/25      | 10     | DEA2      | 18890571956         | Payments/v1.0/casual/creditcard  |
| John Doe       | 371111111111114  | 1234  | AmericanExpress | 01/25      | 10     | DEA2      | 18890571956         | Payments/v1.0/casual/creditcard  |
| John Doe       | 6011111111111117 | 1234  | Discover        | 01/25      | 10     | DEA2      | 18890571956         | Payments/v1.0/casual/creditcard  |
| John Doe       | 3562350000000003 | 1234  | JCB             | 01/25      | 10     | DEA2      | 18890571956         | Payments/v1.0/casual/creditcard  |

@exception
Scenario Outline: Bad Request - 400
Given I have some <endpoint> for casual pay
When I call the method for casual payment with parameters <cardHolderName>, <cardNumber>, <cvc>, <cardType>, <expiryDate>, <amount>, <businessId>, <bpayReferenceNumber>
Then I am able to generate bad response for parameters <cardHolderName>, <cardNumber>, <cvc>, <cardType>, <expiryDate>, <amount>, <businessId>, <bpayReferenceNumber>
Examples: 
| cardHolderName | cardNumber       | cvc   | cardType        | expiryDate | amount | businessId | bpayReferenceNumber | endpoint                        |
| John Doe       | 11111111111111   | 123   | Visa            | 01/25      | 10     | DEA2       | 18890571956         | Payments/v1.0/casual/creditcard |

@exception
Scenario Outline: Unauthorised webpay payment using Visa card - 401
Given I have some <endpoint> for webpay
When I call the post method for <cardHolderName>, <cardNumber>, <cvc>, <cardType>, <expiryDate>, <amount>, <businessId>, <bpayReferenceNumber>, <externalpaymentIdentifier>
Then I am able to generate a response for <cardHolderName>, <cardNumber>, <cvc>, <cardType>, <expiryDate>, <amount>, <businessId>, <bpayReferenceNumber>, <externalpaymentIdentifier>
Examples:
| cardHolderName | cardNumber       | cvc | cardType | expiryDate | amount | businessId | bpayReferenceNumber | externalpaymentIdentifier | endpoint                    |
| John Doe       | 4111111111111111 | 123 | Visa     | 01/25      | 10     | QP1D1      | 18890571956         | 717079468                 | Payments/v1.0/casual/webpay |

@exception
Scenario Outline: Forbidden Access - 403
Given I have some <endpoint> for casual pay
When I call the method for casual payment with parameters <cardHolderName>, <cardNumber>, <cvc>, <cardType>, <expiryDate>, <amount>, <businessId>, <bpayReferenceNumber>
Then I am able to generate forbidden response for parameters <cardHolderName>, <cardNumber>, <cvc>, <cardType>, <expiryDate>, <amount>, <businessId>, <bpayReferenceNumber>
Examples: 
| cardHolderName | cardNumber       | cvc   | cardType        | expiryDate | amount | businessId | bpayReferenceNumber | endpoint                        |
| John Doe       | 4111111111111111 | 123   | Visa            | 01/25      | 10     | QP1D1      | 18890571956         | Payments/v1.0/casual/creditcard |

@exception
Scenario Outline: Conflict error casual pay - 409
Given I have some <endpoint> for casual pay
When I call the method for conflict with parameters <cardHolderName>, <cardNumber>, <cvc>, <cardType>, <expiryDate>, <amount>, <businessId>, <bpayReferenceNumber>
Then I am able to generate the response for conflict with parameters <cardHolderName>, <cardNumber>, <cvc>, <cardType>, <expiryDate>, <amount>, <businessId>, <bpayReferenceNumber>
Examples: 
| cardHolderName | cardNumber       | cvc   | cardType        | expiryDate | amount | businessId | bpayReferenceNumber | endpoint                        |
| John Doe       | 4111111111111111 | 123   | Visa            | 01/25      | 10     | DEA2      | 18890571956         | Payments/v1.0/casual/creditcard  |

@exception
Scenario Outline: Unprocessable Entity for Casual payments - 422
Given I have some <endpoint> for webpay
When I call the method for unprocessable entity with parameters <cardHolderName>, <cardNumber>, <cvc>, <cardType>, <expiryDate>, <amount>, <businessId>, <bpayReferenceNumber>
Then I am able to get a response for unprocessable entity with parameters <cardHolderName>, <cardNumber>, <cvc>, <cardType>, <expiryDate>, <amount>, <businessId>, <bpayReferenceNumber>
Examples:
| cardHolderName | cardNumber       | cvc   | cardType        | expiryDate | amount | businessId | bpayReferenceNumber | endpoint                        |
| John Doe       | 36000000000008   | 1234  | Diners          | 01/25      | 10     | DEA2      | 18890571956         | Payments/v1.0/casual/creditcard  |

@exception
Scenario Outline: Internal server error for Webpay - 500
Given I have some <endpoint> for casual pay
When I call the method to generate internal server error for webpay with parameters <cardHolderName>, <cardNumber>, <cvc>, <cardType>, <expiryDate>, <amount>, <businessId>, <bpayReferenceNumber>
Then I am able to generate internal server error for parameters <cardHolderName>, <cardNumber>, <cvc>, <cardType>, <expiryDate>, <amount>, <businessId>, <bpayReferenceNumber>
Examples: 
| cardHolderName | cardNumber       | cvc   | cardType        | expiryDate | amount | businessId | bpayReferenceNumber | endpoint                        |
| John Doe       | 41111111111111   | 123   | Visa            | 01/25      | 10     | QP1D1      | 18890571956         | Payments/v1.0/casual/webpay     |