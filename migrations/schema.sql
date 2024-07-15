CREATE TABLE IF NOT EXISTS public.priority
(
	id integer NOT NULL DEFAULT nextval('messages_id_seq'::regclass),
    description character varying,
    CONSTRAINT priority_pk PRIMARY KEY (id)
);


CREATE TABLE IF NOT EXISTS public.messages
(
    id integer NOT NULL DEFAULT nextval('messages_id_seq'::regclass),
    message character varying,
    priority_id integer NOT NULL DEFAULT 0,

    CONSTRAINT messages_pk PRIMARY KEY (id),
    CONSTRAINT messages_priority_fk FOREIGN KEY (priority_id)
        REFERENCES public.priority (id) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
);
