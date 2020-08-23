FROM jupyter/minimal-notebook
EXPOSE 8888
RUN pip install pandas
CMD ["jupyter", "notebook", "--no-browser","--NotebookApp.token=''","--NotebookApp.password=''","--NotebookApp.base_url=/analytics"]
#CMD start-notebook.sh --NotebookApp.password='' --NotebookApp.token='' --NotebookApp.base_url=/analytics
#CMD start-notebook.sh --NotebookApp.password='argon2:$argon2id$v=19$m=10240,t=10,p=8$etai0M5SazF2VwIg+4FnpA$teksd6+MhGewSVd1yTW2cw' 

