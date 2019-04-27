--
-- PostgreSQL database dump
--

-- Dumped from database version 11.1
-- Dumped by pg_dump version 11.1

-- Started on 2019-04-26 08:59:01

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
-- TOC entry 8427 (class 0 OID 316017)
-- Dependencies: 217
-- Data for Name: _BaseUrl; Type: TABLE DATA; Schema: public; Owner: Pyro
--

INSERT INTO public."_BaseUrl" VALUES (1, 'localhost:8888/fhir', true, '2019-04-25 12:28:33.699775', 'PyroServerSystem', '2019-04-25 12:28:33.699775', 'PyroServerSystem');
INSERT INTO public."_BaseUrl" VALUES (2, 'hl7.org/fhir', false, '2019-04-25 12:28:47.644186', 'PyroServerSystem', '2019-04-25 12:28:47.644186', 'PyroServerSystem');
INSERT INTO public."_BaseUrl" VALUES (3, 'terminology.hl7.org', false, '2019-04-25 13:07:59.182619', 'PyroServerSystem', '2019-04-25 13:07:59.182619', 'PyroServerSystem');
INSERT INTO public."_BaseUrl" VALUES (4, 'example.org/fhir', false, '2019-04-25 15:25:06.568605', 'PyroServerSystem', '2019-04-25 15:25:06.568605', 'PyroServerSystem');
INSERT INTO public."_BaseUrl" VALUES (5, 'cds-hooks.hl7.org', false, '2019-04-25 15:25:10.196962', 'PyroServerSystem', '2019-04-25 15:25:10.196962', 'PyroServerSystem');


--
-- TOC entry 8433 (class 0 OID 0)
-- Dependencies: 216
-- Name: _BaseUrl_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: Pyro
--

SELECT pg_catalog.setval('public."_BaseUrl_Id_seq"', 5, true);


-- Completed on 2019-04-26 08:59:02

--
-- PostgreSQL database dump complete
--

