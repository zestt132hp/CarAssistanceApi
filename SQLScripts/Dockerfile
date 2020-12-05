FROM library/postgres
ENV POSTGRES_DB=CarAssistance
ENV POSTGRES_USER=admin
ENV POSTGRES_PASSWORD=qwe123
COPY ./SQLScripts/init.sql /docker-entrypoint-initdb.d/
COPY ./SQLScripts/BackUp.sql /var/lib/postgresql/
COPY ./SQLScripts/init.sql /var/lib/postgresql/
COPY ./SQLScripts/Backup.backup /var/lib/postgresql/
ENTRYPOINT ["docker-entrypoint.sh"]
EXPOSE 5432
CMD ["postgres"]
