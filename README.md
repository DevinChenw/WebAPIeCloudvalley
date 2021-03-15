# WebAPIeCloudvalley

Simple API allowing user to view data.

![image](https://github.com/znnylance/WebAPIeCloudvalley/blob/master/Picture/apiuml.png)

## Web API service usage example 

HOST: http://localhost/api/Order

###  GetProductTotalUsageAmount [GET]

+ Response 200 (application/json)
    
        [
            {
                "published_at": "2021-03-15T08:40:51.620Z",
                "Parameters":
                usageaccountid : order1 (string, Required)
                pageSize: 10 (number, optional)
                currentPage: 1 (number, optional)
                Message：Null
                "ProductViewModel": [
                    {
                        "ProductName": "AWS Backup",
                        "TotalUsageAmount": 170
                    }, {
                        "ProductName": "AWS Config",
                        "TotalUsageAmount": 140
                    }
                ]
            }
        ]
        
+ Response 500 (application/json)
    
        [
            {
                "published_at": "2021-03-15T08:40:51.620Z",
                "Parameters":
                usageaccountid : order1 (string, Required)
                pageSize: 10 (number, optional)
                currentPage: 1 (number, optional)
                Message：Request data is empty
                "ProductViewModel": [
                    {
                       
                    }
                ]
            }
        ]

###  GetProductGroupDateTotalUsageAmount [GET]

+ Response 200 (application/json)
    
        [
            {
                "published_at": "2021-03-15T08:40:51.620Z",
                "Parameters":
                usageaccountid : order2 (string, Required)
                pageSize: 10 (number, optional)
                currentPage: 1 (number, optional)
                Message：Null
                "ProductViewModel": [
                    {
                        "ProductName": "AWS Config",
                        "UsageStartDate"："2021/3/1"
                        "TotalUsageAmount": 500
                    }, {
                        "ProductName": "AWS Config",
                        "UsageStartDate"："2021/3/12"
                        "TotalUsageAmount": 80
                    } , {
                        "ProductName": "Amazon Registrar",
                        "UsageStartDate"："2021/3/12"
                        "TotalUsageAmount": 200
                    }, {
                        "ProductName": "Amazon Registrar",
                        "UsageStartDate"："2021/3/1"
                        "TotalUsageAmount": 200
                    }
                ]
            }
        ]
        
+ Response 500 (application/json)
    
        [
            {
                "published_at": "2021-03-15T08:40:51.620Z",
                "Parameters":
                usageaccountid : order2 (string, Required)
                pageSize: 10 (number, optional)
                currentPage: 1 (number, optional)
                Message：Request data is empty
                "ProductViewModel": [
                    {
                       
                    }
                ]
            }
        ]
