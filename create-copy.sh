#!/bin/bash

DATE=$(date +"%FT%T")
FILENAME=$DATE.txt

echo "[INFO] Create test file..."

touch /tmp/$FILENAME

echo "[INFO] Write data to test file..."

echo "Test DATE is $DATE" >> /tmp/$FILENAME

echo "[INFO] Create test directory..."

if [ -d /tmp/testdir/ ]
then
	rm -rf /tmp/testdir/
    mkdir /tmp/testdir/
else
    mkdir /tmp/testdir/
fi

echo "[INFO] Move test file to test directory..."

mv /tmp/$FILENAME /tmp/testdir/

echo "[INFO] Check if test file exists in test directory..."

if [ -e /tmp/testdir/$FILENAME ]
then
    echo "[Test Passed] File $FILENAME exists."
else
    echo "[Test Failed] File $FILENAME not exists."
fi