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
    t.cpay_acc not like '202%' and t.crec_acc not like '202%' and 
    t.cpay_acc not like '912%' and t.crec_acc not like '912%' and 
    T.DTRNTRAN between :beg and :beg + 1 and
    not(t.cpay_acc like '40817%' and ((t.crec_acc like '30233%') or (t.crec_acc like '47422%'))) and 
    not (a1.iaccotd <> o.iusrbranch and substr(t.crec_acc, 1, 5) in ('40502','40602','40702','40703','40802', '40817', '42301')) and
	not (t.ctrnidopen = 'IP_GATE' and t.itrnsop <> 104) and
    not(t.cpay_acc like '60310%' and t.crec_acc like '6%') and
    not(t.cpay_acc like '70%' and t.crec_acc like '6%') and
    not(t.cpay_acc like '47423%' and t.crec_acc like '6%') and
    not(t.cpay_acc like '603%' and t.crec_acc like '4%') and
    not(t.cpay_acc like '47425%' and t.crec_acc like '47425%') and
    not(t.cpay_acc like '40817%' and t.crec_acc like '70601%') and
	not(t.cpay_acc like '60%' and t.crec_acc like '61209%') and
	not(t.cpay_acc like '61209%' and t.crec_acc like '60%') and
	not(t.cpay_acc like '603%' and t.crec_acc like '706%') and
	not(t.cpay_acc like '60401%' and t.crec_acc like '60415%') and
	not(t.cpay_acc = '40702810200000000773' and t.crec_acc = '47422810400701000773') and
	not(t.cpay_acc like '70%' and t.crec_acc like '707%') and
	not(t.cpay_acc like '603%' and t.crec_acc like '707%') and
	not(t.cpay_acc like '707%' and t.crec_acc like '70%') and
	not(t.cpay_acc like '603%' and t.crec_acc like '603%') and
	not(t.cpay_acc like '614%' and t.crec_acc like '603%') and
	not(t.cpay_acc like '61008%' and t.crec_acc like '603%') and
	not(t.cpay_acc like '61008%' and t.crec_acc like '70606%') and
	not(t.cpay_acc like '10601%' and t.crec_acc like '10801%') and
	not(t.cpay_acc like '61009%' and t.crec_acc like '60310%') and
	not(t.cpay_acc like '40911%' and t.crec_acc like '60312%') and
    not(a1.iaccotd <> o.iusrbranch and t.crec_acc like '45%') and
	not(t.itrntype = 2 and a1.iaccotd <> o.iusrbranch) and 
    not(t.cpay_acc like '60312%' and substr(t.crec_acc, 1, 5) in ('40502','40602','40702','40703','40802', '40817'))
)
minus
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
    t.cpay_acc not like '202%' and t.crec_acc not like '202%' and 
    t.cpay_acc not like '912%' and t.crec_acc not like '912%' and
	t.cpay_acc not like '42309%' and t.crec_acc not like '42309%' and
	t.cpay_acc not like '42609%' and t.crec_acc not like '42609%' and
    t.cpay_acc not like '60305810%' and  
	t.cpay_acc not like '40702%' and  
    T.DTRNTRAN between :beg and :beg + 1 and
    ((A1.IACCOTD = o.iusrbranch and t.cpay_acc like '423%') or (a2.iaccotd = o.iusrbranch and t.crec_acc like '423%') or 
    (A1.IACCOTD = o.iusrbranch and t.cpay_acc like '426%') or (a2.iaccotd = o.iusrbranch and t.crec_acc like '426%')) and
    (not (a1.iaccotd <> o.iusrbranch and t.crec_acc like '423__810_0070%') or (t.cpay_acc = '47422810700000000064')) and
    substr(t.cpay_acc, 6, 3) = '810' and substr(t.crec_acc, 6, 3) = '810'
)
minus
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
    t.cpay_acc not like '202%' and t.crec_acc not like '20202%' and 
    t.cpay_acc not like '912%' and t.crec_acc not like '912%' and 
    -- t.cpay_acc not like '423%' and t.crec_acc not like '423%' and
	substr(t.cpay_acc, 1, 5) not in ('42301','42302','42303','42304','42305','42306','42307','42308') and
	substr(t.crec_acc, 1, 5) not in ('42301','42302','42303','42304','42305','42306','42307','42308') and
    (not (t.cpay_acc like '70%' and t.crec_acc like '6%') or (t.cpay_acc = '70606810200704730402' and t.crec_acc = '60324810700000000123')) and
    not (t.cpay_acc like '70801%' and t.crec_acc like '707%') and
	not (t.cpay_acc like '707%' and t.crec_acc like '708%') and
    (not (t.cpay_acc like '603%' and t.crec_acc like '70606%') or (t.cpay_acc = '60324810700000000123' and t.crec_acc = '70606810900704730401')) and
	not (t.cpay_acc like '707%' and t.crec_acc like '706%') and
	not (t.cpay_acc like '706%' and t.crec_acc like '707%') and
	not (t.cpay_acc like '10601%' and t.crec_acc like '10601%') and
	not (t.cpay_acc like '30102%' and t.crec_acc like '20209%') and
	not (t.cpay_acc like '47423%' and t.crec_acc like '47416%') and
	not (t.cpay_acc like '40101%' and t.crec_acc like '47416%') and
	not (t.cpay_acc like '47416%' and t.crec_acc like '47423%') and
	not (t.cpay_acc like '60335%' and t.crec_acc like '70601%') and
	not (t.cpay_acc like '60305%' and t.crec_acc like '70601%') and
	not (t.cpay_acc like '40702%' and t.crec_acc like '61301%') and
	not (t.cpay_acc like '61403%' and t.crec_acc like '70606%') and
	not (t.cpay_acc like '61008%' and t.crec_acc like '70606%') and
	not (t.cpay_acc like '47444%' and t.crec_acc like '47427%') and
	not (t.cpay_acc like '6031%') and
    T.DTRNTRAN between :beg and :beg + 1 and
    (
        ((A1.IACCOTD = o.iusrbranch and t.cpay_acc like '70%') or (a2.iaccotd = o.iusrbranch and t.crec_acc like '70%')) or 
        (t.cpay_acc like '474%' and t.crec_acc like '474%') or
        (t.cpay_acc like '70606%' and t.crec_acc like '47411%') or
        (t.crec_acc = '61214810600700000001') or
        (t.crec_acc like '61301810_007%') or
        (t.cpay_acc = '61214810600700000001') or
        (t.cpay_acc = '47423810900000000012' and t.crec_acc like '70706%') or
        (t.cpay_acc like '40%' and t.crec_acc = '70601810900001210218') or 
		(t.cpay_acc = '30102810100000000001' and t.crec_acc = '20209810600700000002') or 
		(t.cpay_acc = '40817810400700005514' and t.crec_acc = '70601810800702730401')
    ) and
    A1.CACCCUR = 'RUR' and A2.CACCCUR = 'RUR'
)
minus
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
    t.cpay_acc not like '202%' and t.crec_acc not like '202%' and 
    t.cpay_acc not like '912%' and t.crec_acc not like '912%' and 
    T.DTRNTRAN between :beg and :beg + 1 and
    (
        (A1.CACCCUR <> 'RUR' or A2.CACCCUR <> 'RUR')
    ))
minus
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
    t.cpay_acc not like '202%' and t.crec_acc not like '202%' and 
    t.cpay_acc not like '912%' and t.crec_acc not like '912%' and 
    T.DTRNTRAN between :beg and :beg + 1 and
    (
        t.cpay_acc like '9%'
    ))
minus
(
select
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