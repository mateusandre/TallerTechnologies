select
 isnull(custormer.FirstName) + ' ' + isnull(customer.LastName) as 'Full Name',
 customer.Age,
 orders.OrderID,
 orders.DateCreated,
 orders.MethododPurchase as 'Purchase Method',
 details.ProductNumber,
 details.ProductOrigin
from Customer customer
inner join Orders orders on orders.PersonID = customer.PersonID
inner join OrdersDetails details on details.OrderID = orders.OrderID
where details.ProductID = 1112222333