
create or alter procedure GetDetailUser
(
@Email as varchar(500)
)
as
begin
set nocount on 



select
UA.UserNumber,
UAD.FullName ,
UA.EmailAddress,
UA.Passwords,
UAD.NumberPhone,
UAD.Nationality,
UA.CreatedDated
from UserAccount UA
join UserAccountDetail UAD
on UA.UserNumber = UAD.UserNumber
where UA.EmailAddress=@Email

end

