select * from INT_MAPEAMENTO;

select * from INT_INTERFACEREST;

update INT_INTERFACEREST set url = 'http://200.201.206.200:888/api/millenium_eco/produtos/listavitrine?VITRINE=13&$format=json&$top=5' where id = 2;
update INT_INTERFACEREST set RETURNROOTELEMENTPAI = NULL;
update INT_INTERFACEREST set RETURNROOTELEMENTPAI = 'root';
update INT_INTERFACEREST set RETURNROOTELEMENTLISTA = NULL;

select * from INT_INTEGRACAO;
select * from INT_FILA;

update INT_INTEGRACAO set PKPRIMARIA = 'produto' where ID = 1;
update INT_INTEGRACAO set DATAHORAULTIMAEXECUCAO = NULL where ID = 1;
update INT_INTEGRACAO set DATAHORAULTIMAEXECUCAO = NULL where ID = 2;

update INT_INTEGRACAO set [STATUS] = 0 where ID = 1;
update INT_INTEGRACAO set [STATUS] = 1 where ID = 2;
update INT_INTEGRACAO set INTERFACEID = 2 where ID = 2;
update INT_INTEGRACAO set ADAPTERID = 4 where ID = 2;

select * from INT_MAPEAMENTO;
update INT_MAPEAMENTO set de = 'root/value', para = 'produto' where id = 1;
update INT_MAPEAMENTO set de = 'root/value/produto' where id = 2;

update INT_MAPEAMENTO set PAIID = 2002 where id = 1002;
update INT_MAPEAMENTO set PAIID = 2002 where id = 1003;
update INT_MAPEAMENTO set PAIID = 2002 where id = 1004;

insert into INT_MAPEAMENTO (INTEGRACAOID, DE, PARA, MULTI) values (2, 'root/value', 'produtos', 1);

update INT_MAPEAMENTO set ELEMENTOMULT = 'value' where ID IN (1002, 1003, 1004);

update INT_MAPEAMENTO set INTEGRACAOID = 2;

insert into INT_MAPEAMENTO (INTEGRACAOID, DE, PARA, VALOR) values
(2, 'root/value/cod_produto', 'code', NULL),
(2, 'root/value/descricao', 'name', NULL),
(2, NULL, 'promotionStore', 'N')


select * from INT_INTEGRACAO;

select * from INT_ADAPTER;

insert into INT_INTEGRACAO (ID, NOME, INTERFACEID, ADAPTERID, EXECUCAOMINUTOS, PKPRIMARIA, CONSUMIDOR) values
(1, 'INTEGRAÇÃO PRODUTO EXECUTORA', 2, 4, 5, 'cod_produto', NULL),
(2, 'INTEGRAÇÃO PRODUTO CONSUMIDORA', 1002, 4, 5, 'cod_produto', NULL)

update INT_INTEGRACAO set ACAOINICIAL = NULL where id = 2;
update INT_INTEGRACAO set ACAOCABECALHO = 'Selia.Integrador.MDias.AcaoCabecalho,Selia.Integrador.MDias;PegaTokenNeo' where id = 2; 

select * from INT_INTERFACEREST;
select * from INT_SISTEMA;

select * from INT_VERBOHTTP;

insert into INT_INTERFACEREST (NOME, SISTEMAID, URL, [LOGIN], SENHA, VERBOHTTPID, TIPOAUTENTICACAOID, CONTENTTYPE) values
('INTEGRAÇÃO PRODUTO NEO', 2, 'http://adm-produto-hmg-neo1.jet.com.br/api/v1/adm_products', 'mdias_admproduto', 'admpromdias2@17', 2, 1, 1);


update INT_INTERFACEREST set CONTENTTYPEID = 1;

update INT_INTERFACEREST set [LOGIN] = NULL, SENHA = NULL WHERE ID = 1002;

select * from INT_TIPOAUTENTICACAOREST;

select * from INT_MAPEAMENTO;

select * from INT_INTEGRACAO;

update INT_INTEGRACAO set DESTINOID = 2 where ID = 1;

update INT_INTEGRACAO set DATAHORAULTIMAEXECUCAO = null;
update INT_INTEGRACAO set EMUSO = 0;
select * from INT_INTEGRACAO;

alter table INT_INTEGRACAO
add ACAOCABECALHO varchar(255);

select * from INT_CABECALHOREST;

select * from INT_FILA;

update INT_INTEGRACAO set CONSUMIDOR = 1 where id = 2;

select * from INT_MAPEAMENTO;
update INT_MAPEAMENTO set DE = 'root/value/nome_produto_site' where iD = 1003;

delete from INT_FILA where ID = 3; 


select * from INT_INTEGRACAO;

update INT_INTEGRACAO set ELEMENTOREGISTRO = 'root/value' where id = 1;
update INT_INTEGRACAO set ACAOFINAL = 'Selia.Integrador.MDias.AcaoFinal,Selia.Integrador.MDias;RemoveNodesNaoUtilizados' where id = 1;

alter table INT_MAPEAMENTO
add ELEMENTOMULT varchar(255);

alter table INT_INTEGRACAO
add NODESNAOUTILIZADOS varchar(255);

update INT_INTEGRACAO set NODESNAOUTILIZADOS = '/root/odata.metadata;/root/odata.count' where id = 1;