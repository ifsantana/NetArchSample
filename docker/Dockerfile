FROM mcr.microsoft.com/mssql/server
USER root

ENV ACCEPT_EULA=Y
ENV SA_PASSWORD=Your_password123
ENV MSSQL_AGENT_ENABLED=true

COPY setup.sql setup.sql
COPY import-data.sh import-data.sh
COPY entrypoint.sh entrypoint.sh

RUN chmod +x entrypoint.sh

USER mssql
ENTRYPOINT /bin/bash ./entrypoint.sh