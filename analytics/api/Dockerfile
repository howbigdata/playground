FROM python:3.7-alpine
COPY requirements.txt /
RUN pip install -r /requirements.txt
COPY src/ /app
WORKDIR /app
ENTRYPOINT [ "python" ]
CMD [ "solver.py" ]
