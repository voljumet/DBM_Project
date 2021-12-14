
---Q1 -- OK (error in the created data will give multiple of the same row)
--- Give me the 100 devices that have been online for the longest time.
select R.acctstarttime, D.MAC
from deviceownership_dim D, radacct_dim R
where D.mac = R.username
ORDER BY R.acctstarttime ASC LIMIT 100;

---Q2 -- OK
--- Use the question over, and sort by students.
select R.acctstarttime, D.MAC
from deviceownership_dim D, radacct_dim R, applicationuser_dim A
where D.mac = R.username and A.email = D.owneremail and A.groupmembership = 0
ORDER BY R.acctstarttime ASC LIMIT 100;

---Q3 -- OK
--- Give me all devices that have been authenticated more than half a year ago.
select R.username, R.acctstarttime, D.mac
from deviceownership_dim D, radacct_dim R
where R.acctstarttime > "2021-06-17 13:10:11" and R.username = D.mac;

---Q4 -- OK
--- Give me all active user emails on a specific VLAN.
select D.owneremail,  D.vlan
from deviceownership_dim D
where D.vlan = "Vlan2" and D.state = 1;

---Q5 -- OK
--- Give me the email to all devices that are connected to a VLAN, that can no longer be used
select D.owneremail, D.mac, R.value
from radreply_dim R, deviceownership_dim D
where D.mac = R.username and R.value = "Vlan4" and D.state = 2;

---Q6 -- OK
--- Compare different VLANs → how many active devices are on each VLAN
select count(R.username) as number_of_mac_addresses, R.value
from radreply_dim R, deviceownership_dim D
where D.mac = R.username and D.state = 1
group by R.value;

---Q7 -- OK
--- Give me the total number of non-active devices for the given VLAN.
select count(R.username) as Number_of_non_active_devices
from deviceownership_dim D, radreply_dim R
where D.mac = R.username and R.value = "Vlan3" and NOT D.state = 1;

---Q8 -- OK
-- Give me devices connected/active between the dates "01.01.2021" to "01.02.2021" 
select  R.username as MAC_Address, D.owneremail as Owner_Email
from radacct_dim R, deviceownership_dim D
where R.acctstarttime <= "2021-03-25 13:10:11" and (R.acctstoptime >= "2021-03-25 13:10:11" or R.acctstoptime = null) and R.username = D.mac;

---Q9 -- OK
--- Give me all user emails and their number of devices, sorted by the number of devices.
select D.owneremail, count(D.devicename) as number_of_devices
from deviceownership_dim D
group by (D.OwnerEmail);

---Q10 -- OK
use ADB1;
select avg(DATEDIFF(D.dateregistered,R.acctstarttime)) as average_time_from_auth_to_fist_connection
from radacct_dim R, deviceownership_dim D
where NOT D.state = 0;

---Q11 -- OK
select sum( DATEDIFF(CURRENT_TIMESTAMP(), R.acctstoptime)) / count(D.MAC) as days_average_until_deleted
from radacct_dim R, deviceownership_dim D
where D.state = 2 and D.MAC = R.username and R.acctstoptime < CURRENT_TIMESTAMP();

---Q12 -- OK!
select (sum(R.acctinputoctets) / count(D.MAC)) as sumy
from radacct_dim R, deviceownership_dim D, applicationuser_dim A
where A.groupmembership = 0 and R.username = D.mac and A.email = D.owneremail;



