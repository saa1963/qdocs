with otdel as (select iusrbranch from XXI.usr where cusrlogname = sys_context ('USERENV','CURRENT_USER'))
(select
    T.ITRNDOCNUM num,
    T.CTRNVO operationcode,
    T.MTRNRSUM sm,
    nvl(t.cpay_bic, '046850755') ticdebet,
    nvl(t.crec_bic, '046850755') ticcredit,
    t.cpay_acc debetaccount,
    t.crec_acc creditaccount,
    T.CTRNCLIENT_NAME debetname,
    T.CTRNOWNA creditname,
    T.CTRNPURP info,
    nvl(i.ccreatstatus, '') ccreatstatus, 
    nvl(i.cbudcode, '') cbudcode, 
    nvl(i.cokatocode, '') cokatocode,
    nvl(i.cnalpurp, '') cnalpurp,
    nvl(i.cnalperiod, '') cnalperiod,
    nvl(i.cnaldocnum, '') cnaldocnum,
    nvl(i.cnaldocdate, '') cnaldocdate,
    nvl(i.cnaltype, '') cnaltype,
    substr(t.cpay_acc, 1, 5) || substr(t.cpay_acc, 14, 7) srt
from 
    XXI.v_pdoc_mf t left join XXI.acc a1 on t.cpay_acc = a1.caccacc 
    left join XXI.acc a2 on t.crec_acc = a2.caccacc 
    left join XXI.trn_dept_info i on t.itrnnum = i.inum and t.itrnanum = i.ianum, otdel o  
where
    (a1.iaccotd = o.iusrbranch or a2.iaccotd = o.iusrbranch) and
    t.itrntype not in (5,41,42,43,44,50,53,9,10,12,13,-3) and
    T.DTRNTRAN between :beg and :beg + 1 and
	((
    A1.IACCOTD = o.iusrbranch and 
	t.cpay_acc like '40817%' and 
	t.crec_acc like '30233%'
	) or 
	(
	A2.IACCOTD = o.iusrbranch and 
	t.cpay_acc like '30233%' and
	t.crec_acc like '40817%'
	)) and 
    substr(t.cpay_acc, 6, 3) = '810' and substr(t.crec_acc, 6, 3) = '810'
)
order by srt, num