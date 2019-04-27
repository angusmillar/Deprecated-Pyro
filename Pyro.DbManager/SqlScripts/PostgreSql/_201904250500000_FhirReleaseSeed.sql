--
-- PostgreSQL database dump
--

-- Dumped from database version 11.1
-- Dumped by pg_dump version 11.1

-- Started on 2019-04-26 09:00:25

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
-- TOC entry 8426 (class 0 OID 315915)
-- Dependencies: 201
-- Data for Name: _FhirRelease; Type: TABLE DATA; Schema: public; Owner: Pyro
--

INSERT INTO public."_FhirRelease" VALUES (1, '4.0.0', '2018-12-27 12:00:00', 'FHIR Release #4: First Normative Content', '2019-04-25 14:30:00', 'PyroServerSystem', '2019-04-25 14:30:00', 'PyroServerSystem');


--
-- TOC entry 8432 (class 0 OID 0)
-- Dependencies: 200
-- Name: _FhirRelease_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: Pyro
--

SELECT pg_catalog.setval('public."_FhirRelease_Id_seq"', 1, true);


-- Completed on 2019-04-26 09:00:26

--
-- PostgreSQL database dump complete
--

