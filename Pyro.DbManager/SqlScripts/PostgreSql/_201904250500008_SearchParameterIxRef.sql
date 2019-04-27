--
-- PostgreSQL database dump
--

-- Dumped from database version 11.1
-- Dumped by pg_dump version 11.1

-- Started on 2019-04-26 09:06:18

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET client_min_messages = warning;
SET row_security = off;

--
-- TOC entry 8433 (class 0 OID 327156)
-- Dependencies: 1911
-- Data for Name: SearchParameterIxRef; Type: TABLE DATA; Schema: public; Owner: Pyro
--

INSERT INTO public."SearchParameterIxRef" VALUES (169, 'PlanDefinition-context-type', 'SearchParameter', 2, NULL, 39, 1410);
INSERT INTO public."SearchParameterIxRef" VALUES (170, 'PlanDefinition-context-quantity', 'SearchParameter', 2, NULL, 39, 1410);
INSERT INTO public."SearchParameterIxRef" VALUES (171, 'PlanDefinition-context-type', 'SearchParameter', 2, NULL, 39, 1411);
INSERT INTO public."SearchParameterIxRef" VALUES (172, 'PlanDefinition-context', 'SearchParameter', 2, NULL, 39, 1411);
INSERT INTO public."SearchParameterIxRef" VALUES (173, 'Questionnaire-context-type', 'SearchParameter', 2, NULL, 39, 1412);
INSERT INTO public."SearchParameterIxRef" VALUES (174, 'Questionnaire-context-quantity', 'SearchParameter', 2, NULL, 39, 1412);
INSERT INTO public."SearchParameterIxRef" VALUES (175, 'Questionnaire-context-type', 'SearchParameter', 2, NULL, 39, 1413);
INSERT INTO public."SearchParameterIxRef" VALUES (176, 'Questionnaire-context', 'SearchParameter', 2, NULL, 39, 1413);
INSERT INTO public."SearchParameterIxRef" VALUES (187, 'RiskEvidenceSynthesis-context-type', 'SearchParameter', 2, NULL, 39, 1419);
INSERT INTO public."SearchParameterIxRef" VALUES (188, 'RiskEvidenceSynthesis-context', 'SearchParameter', 2, NULL, 39, 1419);
INSERT INTO public."SearchParameterIxRef" VALUES (189, 'TestScript-context-type', 'SearchParameter', 2, NULL, 39, 1420);
INSERT INTO public."SearchParameterIxRef" VALUES (190, 'TestScript-context-quantity', 'SearchParameter', 2, NULL, 39, 1420);
INSERT INTO public."SearchParameterIxRef" VALUES (191, 'TestScript-context-type', 'SearchParameter', 2, NULL, 39, 1421);
INSERT INTO public."SearchParameterIxRef" VALUES (192, 'TestScript-context', 'SearchParameter', 2, NULL, 39, 1421);
INSERT INTO public."SearchParameterIxRef" VALUES (97, 'ActivityDefinition-context-type', 'SearchParameter', 2, NULL, 39, 1376);
INSERT INTO public."SearchParameterIxRef" VALUES (98, 'ActivityDefinition-context-quantity', 'SearchParameter', 2, NULL, 39, 1376);
INSERT INTO public."SearchParameterIxRef" VALUES (99, 'ActivityDefinition-context-type', 'SearchParameter', 2, NULL, 39, 1377);
INSERT INTO public."SearchParameterIxRef" VALUES (100, 'ActivityDefinition-context', 'SearchParameter', 2, NULL, 39, 1377);
INSERT INTO public."SearchParameterIxRef" VALUES (101, 'conformance-context-type', 'SearchParameter', 2, NULL, 39, 1378);
INSERT INTO public."SearchParameterIxRef" VALUES (102, 'conformance-context-quantity', 'SearchParameter', 2, NULL, 39, 1378);
INSERT INTO public."SearchParameterIxRef" VALUES (103, 'conformance-context-type', 'SearchParameter', 2, NULL, 39, 1379);
INSERT INTO public."SearchParameterIxRef" VALUES (104, 'conformance-context', 'SearchParameter', 2, NULL, 39, 1379);
INSERT INTO public."SearchParameterIxRef" VALUES (105, 'ChargeItemDefinition-context-type', 'SearchParameter', 2, NULL, 39, 1380);
INSERT INTO public."SearchParameterIxRef" VALUES (106, 'ChargeItemDefinition-context-quantity', 'SearchParameter', 2, NULL, 39, 1380);
INSERT INTO public."SearchParameterIxRef" VALUES (107, 'ChargeItemDefinition-context-type', 'SearchParameter', 2, NULL, 39, 1381);
INSERT INTO public."SearchParameterIxRef" VALUES (108, 'ChargeItemDefinition-context', 'SearchParameter', 2, NULL, 39, 1381);
INSERT INTO public."SearchParameterIxRef" VALUES (109, 'DocumentReference-relatesto', 'SearchParameter', 2, NULL, 39, 1382);
INSERT INTO public."SearchParameterIxRef" VALUES (110, 'DocumentReference-relation', 'SearchParameter', 2, NULL, 39, 1382);
INSERT INTO public."SearchParameterIxRef" VALUES (111, 'EffectEvidenceSynthesis-context-type', 'SearchParameter', 2, NULL, 39, 1383);
INSERT INTO public."SearchParameterIxRef" VALUES (112, 'EffectEvidenceSynthesis-context-quantity', 'SearchParameter', 2, NULL, 39, 1383);
INSERT INTO public."SearchParameterIxRef" VALUES (113, 'EffectEvidenceSynthesis-context-type', 'SearchParameter', 2, NULL, 39, 1384);
INSERT INTO public."SearchParameterIxRef" VALUES (114, 'EffectEvidenceSynthesis-context', 'SearchParameter', 2, NULL, 39, 1384);
INSERT INTO public."SearchParameterIxRef" VALUES (115, 'EventDefinition-context-type', 'SearchParameter', 2, NULL, 39, 1385);
INSERT INTO public."SearchParameterIxRef" VALUES (116, 'EventDefinition-context-quantity', 'SearchParameter', 2, NULL, 39, 1385);
INSERT INTO public."SearchParameterIxRef" VALUES (117, 'EventDefinition-context-type', 'SearchParameter', 2, NULL, 39, 1386);
INSERT INTO public."SearchParameterIxRef" VALUES (118, 'EventDefinition-context', 'SearchParameter', 2, NULL, 39, 1386);
INSERT INTO public."SearchParameterIxRef" VALUES (119, 'Evidence-context-type', 'SearchParameter', 2, NULL, 39, 1387);
INSERT INTO public."SearchParameterIxRef" VALUES (120, 'Evidence-context-quantity', 'SearchParameter', 2, NULL, 39, 1387);
INSERT INTO public."SearchParameterIxRef" VALUES (121, 'Evidence-context-type', 'SearchParameter', 2, NULL, 39, 1388);
INSERT INTO public."SearchParameterIxRef" VALUES (122, 'Evidence-context', 'SearchParameter', 2, NULL, 39, 1388);
INSERT INTO public."SearchParameterIxRef" VALUES (123, 'EvidenceVariable-context-type', 'SearchParameter', 2, NULL, 39, 1389);
INSERT INTO public."SearchParameterIxRef" VALUES (124, 'EvidenceVariable-context-quantity', 'SearchParameter', 2, NULL, 39, 1389);
INSERT INTO public."SearchParameterIxRef" VALUES (125, 'EvidenceVariable-context-type', 'SearchParameter', 2, NULL, 39, 1390);
INSERT INTO public."SearchParameterIxRef" VALUES (126, 'EvidenceVariable-context', 'SearchParameter', 2, NULL, 39, 1390);
INSERT INTO public."SearchParameterIxRef" VALUES (127, 'ExampleScenario-context-type', 'SearchParameter', 2, NULL, 39, 1391);
INSERT INTO public."SearchParameterIxRef" VALUES (128, 'ExampleScenario-context-quantity', 'SearchParameter', 2, NULL, 39, 1391);
INSERT INTO public."SearchParameterIxRef" VALUES (129, 'ExampleScenario-context-type', 'SearchParameter', 2, NULL, 39, 1392);
INSERT INTO public."SearchParameterIxRef" VALUES (130, 'ExampleScenario-context', 'SearchParameter', 2, NULL, 39, 1392);
INSERT INTO public."SearchParameterIxRef" VALUES (131, 'Group-characteristic', 'SearchParameter', 2, NULL, 39, 1393);
INSERT INTO public."SearchParameterIxRef" VALUES (132, 'Group-value', 'SearchParameter', 2, NULL, 39, 1393);
INSERT INTO public."SearchParameterIxRef" VALUES (133, 'Library-context-type', 'SearchParameter', 2, NULL, 39, 1394);
INSERT INTO public."SearchParameterIxRef" VALUES (134, 'Library-context-quantity', 'SearchParameter', 2, NULL, 39, 1394);
INSERT INTO public."SearchParameterIxRef" VALUES (135, 'Library-context-type', 'SearchParameter', 2, NULL, 39, 1395);
INSERT INTO public."SearchParameterIxRef" VALUES (136, 'Library-context', 'SearchParameter', 2, NULL, 39, 1395);
INSERT INTO public."SearchParameterIxRef" VALUES (137, 'Measure-context-type', 'SearchParameter', 2, NULL, 39, 1396);
INSERT INTO public."SearchParameterIxRef" VALUES (138, 'Measure-context-quantity', 'SearchParameter', 2, NULL, 39, 1396);
INSERT INTO public."SearchParameterIxRef" VALUES (139, 'Measure-context-type', 'SearchParameter', 2, NULL, 39, 1397);
INSERT INTO public."SearchParameterIxRef" VALUES (140, 'Measure-context', 'SearchParameter', 2, NULL, 39, 1397);
INSERT INTO public."SearchParameterIxRef" VALUES (141, 'MolecularSequence-chromosome', 'SearchParameter', 2, NULL, 39, 1398);
INSERT INTO public."SearchParameterIxRef" VALUES (142, 'MolecularSequence-variant-start', 'SearchParameter', 2, NULL, 39, 1398);
INSERT INTO public."SearchParameterIxRef" VALUES (143, 'MolecularSequence-variant-end', 'SearchParameter', 2, NULL, 39, 1398);
INSERT INTO public."SearchParameterIxRef" VALUES (144, 'MolecularSequence-chromosome', 'SearchParameter', 2, NULL, 39, 1399);
INSERT INTO public."SearchParameterIxRef" VALUES (145, 'MolecularSequence-window-start', 'SearchParameter', 2, NULL, 39, 1399);
INSERT INTO public."SearchParameterIxRef" VALUES (146, 'MolecularSequence-window-end', 'SearchParameter', 2, NULL, 39, 1399);
INSERT INTO public."SearchParameterIxRef" VALUES (147, 'MolecularSequence-referenceseqid', 'SearchParameter', 2, NULL, 39, 1400);
INSERT INTO public."SearchParameterIxRef" VALUES (148, 'MolecularSequence-variant-start', 'SearchParameter', 2, NULL, 39, 1400);
INSERT INTO public."SearchParameterIxRef" VALUES (149, 'MolecularSequence-variant-end', 'SearchParameter', 2, NULL, 39, 1400);
INSERT INTO public."SearchParameterIxRef" VALUES (150, 'MolecularSequence-referenceseqid', 'SearchParameter', 2, NULL, 39, 1401);
INSERT INTO public."SearchParameterIxRef" VALUES (151, 'MolecularSequence-window-start', 'SearchParameter', 2, NULL, 39, 1401);
INSERT INTO public."SearchParameterIxRef" VALUES (152, 'MolecularSequence-window-end', 'SearchParameter', 2, NULL, 39, 1401);
INSERT INTO public."SearchParameterIxRef" VALUES (153, 'clinical-code', 'SearchParameter', 2, NULL, 39, 1402);
INSERT INTO public."SearchParameterIxRef" VALUES (154, 'Observation-value-concept', 'SearchParameter', 2, NULL, 39, 1402);
INSERT INTO public."SearchParameterIxRef" VALUES (155, 'clinical-code', 'SearchParameter', 2, NULL, 39, 1403);
INSERT INTO public."SearchParameterIxRef" VALUES (156, 'Observation-value-date', 'SearchParameter', 2, NULL, 39, 1403);
INSERT INTO public."SearchParameterIxRef" VALUES (157, 'clinical-code', 'SearchParameter', 2, NULL, 39, 1404);
INSERT INTO public."SearchParameterIxRef" VALUES (158, 'Observation-value-quantity', 'SearchParameter', 2, NULL, 39, 1404);
INSERT INTO public."SearchParameterIxRef" VALUES (159, 'clinical-code', 'SearchParameter', 2, NULL, 39, 1405);
INSERT INTO public."SearchParameterIxRef" VALUES (160, 'Observation-value-string', 'SearchParameter', 2, NULL, 39, 1405);
INSERT INTO public."SearchParameterIxRef" VALUES (161, 'Observation-combo-code', 'SearchParameter', 2, NULL, 39, 1406);
INSERT INTO public."SearchParameterIxRef" VALUES (162, 'Observation-combo-value-concept', 'SearchParameter', 2, NULL, 39, 1406);
INSERT INTO public."SearchParameterIxRef" VALUES (163, 'Observation-combo-code', 'SearchParameter', 2, NULL, 39, 1407);
INSERT INTO public."SearchParameterIxRef" VALUES (164, 'Observation-combo-value-quantity', 'SearchParameter', 2, NULL, 39, 1407);
INSERT INTO public."SearchParameterIxRef" VALUES (165, 'Observation-component-code', 'SearchParameter', 2, NULL, 39, 1408);
INSERT INTO public."SearchParameterIxRef" VALUES (166, 'Observation-component-value-concept', 'SearchParameter', 2, NULL, 39, 1408);
INSERT INTO public."SearchParameterIxRef" VALUES (167, 'Observation-component-code', 'SearchParameter', 2, NULL, 39, 1409);
INSERT INTO public."SearchParameterIxRef" VALUES (168, 'Observation-component-value-quantity', 'SearchParameter', 2, NULL, 39, 1409);
INSERT INTO public."SearchParameterIxRef" VALUES (177, 'ResearchDefinition-context-type', 'SearchParameter', 2, NULL, 39, 1414);
INSERT INTO public."SearchParameterIxRef" VALUES (178, 'ResearchDefinition-context-quantity', 'SearchParameter', 2, NULL, 39, 1414);
INSERT INTO public."SearchParameterIxRef" VALUES (179, 'ResearchDefinition-context-type', 'SearchParameter', 2, NULL, 39, 1415);
INSERT INTO public."SearchParameterIxRef" VALUES (180, 'ResearchDefinition-context', 'SearchParameter', 2, NULL, 39, 1415);
INSERT INTO public."SearchParameterIxRef" VALUES (181, 'ResearchElementDefinition-context-type', 'SearchParameter', 2, NULL, 39, 1416);
INSERT INTO public."SearchParameterIxRef" VALUES (182, 'ResearchElementDefinition-context-quantity', 'SearchParameter', 2, NULL, 39, 1416);
INSERT INTO public."SearchParameterIxRef" VALUES (183, 'ResearchElementDefinition-context-type', 'SearchParameter', 2, NULL, 39, 1417);
INSERT INTO public."SearchParameterIxRef" VALUES (184, 'ResearchElementDefinition-context', 'SearchParameter', 2, NULL, 39, 1417);
INSERT INTO public."SearchParameterIxRef" VALUES (185, 'RiskEvidenceSynthesis-context-type', 'SearchParameter', 2, NULL, 39, 1418);
INSERT INTO public."SearchParameterIxRef" VALUES (186, 'RiskEvidenceSynthesis-context-quantity', 'SearchParameter', 2, NULL, 39, 1418);


--
-- TOC entry 8439 (class 0 OID 0)
-- Dependencies: 1910
-- Name: SearchParameterIxRef_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: Pyro
--

SELECT pg_catalog.setval('public."SearchParameterIxRef_Id_seq"', 192, true);


-- Completed on 2019-04-26 09:06:19

--
-- PostgreSQL database dump complete
--

