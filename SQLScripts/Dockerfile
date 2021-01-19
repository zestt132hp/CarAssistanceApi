FROM library/postgres
ENV POSTGRES_DB=CarAssistanceDb
ENV POSTGRES_USER=postgres
ENV POSTGRES_PASSWORD=qwe123
COPY ./SQLScripts/BackUp.sql /var/lib/postgresql/
COPY ./SQLScripts/init.sql /var/lib/postgresql/
COPY ./SQLScripts/Backup.backup /var/lib/postgresql/
COPY ./SQLScripts/init.sql /docker-entrypoint-initdb.d/
RUN chown postgres:postgres /docker-entrypoint-initdb.d/init.sql
ENTRYPOINT ["docker-entrypoint.sh"]
EXPOSE 5432
CMD ["postgres"]