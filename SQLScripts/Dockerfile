FROM library/postgres
ENV POSTGRES_DB=CarAssistance
ENV POSTGRES_USER=admin
ENV POSTGRES_PASSWORD=qwe123
RUN ["mkdir", "/docker-entrypoint-initdb.d"]
COPY init.sql /docker-entrypoint-initdb.d/
